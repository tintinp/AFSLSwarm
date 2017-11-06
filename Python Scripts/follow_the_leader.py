#!/usr/bin/env python
# -*- coding: utf-8 -*-

from __future__ import print_function
import time
import re
from dronekit import connect, VehicleMode, LocationGlobalRelative
import datetime

UPDATE_TIME = 5
HOVER_ALT = 5

# Set up option parsing to get connection string
import argparse
parser = argparse.ArgumentParser(description="Commands vehicle using vehicle.simple_goto.")
parser.add_argument("--connect1",
                    help="First vehicle connection target string. If not specified, SITL automatically started and used.")
parser.add_argument("--connect2",
					help="First vehicle connection target string. If not specified, SITL automatically started and used.")
args = parser.parse_args()

connection_string_1 = args.connect1
connection_string_2 = args.connect2
text_file = open("GPS_data.txt", "w")
text_file.write("Time \t \t Leader \t \t Follower")


# Connect leader
print("  Connecting to vehicle 1 on: %s" % connection_string_1)
leader = connect(connection_string_1, wait_ready=False)
#leader.wait_ready("armed" , "mode", "attitude", "gps0", "parameters")
print(">>>Leader connected")

# Connect follower
print("  Connecting to vehicle 2 on: %s" % connection_string_2)
follower = connect(connection_string_2, wait_ready=False)
#follower.wait_ready("armed" , "mode", "attitude", "gps0", "parameters")
print(">>>Follower connected")

def arm(vehicle, vehicle_type):
	"""
	Arms vehicle
	"""

	print(">>>Basic pre-arm checks")
	# Don't try to arm until autopilot is ready
	while not vehicle.is_armable:
		print("  Waiting for vehicle to initialize...")
		time.sleep(1)

	print(">>>Arming motors")
	if vehicle_type == 1:
		vehicle.mode = VehicleMode("MANUAL")
	elif vehicle_type == 2:
		# Copter should arm in GUIDED mode
		vehicle.mode = VehicleMode("GUIDED")
	else:
		raise Exception(">>>Invalid vehicle type")

	vehicle.armed = True

	print(">>>Armed? %r" %vehicle.armed);

	# Confirm vehicle armed before attempting to take off
	while not vehicle.armed:
		print("  Waiting for arming...")
		time.sleep(1)

	print("**Vehicle ARMED**")

def takeoff(vehicle, targetAltitude):
	# Take off to target altitude
	if vehicle.armed:
		print("***Taking off!***")
		vehicle.simple_takeoff(targetAltitude)

		# Wait until the vehicle reaches a safe height before processing the goto
	    #  (otherwise the command after Vehicle.simple_takeoff will execute
	    #   immediately).
		while True:
			print("  Altitude: ", vehicle.location.global_relative_frame.alt)
			if vehicle.location.global_relative_frame.alt >= targetAltitude * 0.95:
				print(">>>Reached target altitude")
				break
			time.sleep(1)

def follow_the_leader(leader, follower):
	leader_location_raw = str(leader.location.global_frame)
	follower_location_raw = str(follower.location.global_frame)
	
	# Use regex to process lat and long from leader's location string
	regex = r"(-?\d+\.\d+)"
	match = re.findall(regex, leader_location_raw)
	lat = float(match[0])
	lon = float(match[1])
	match2 = re.findall(regex, follower_location_raw)
	lat_follower = float(match2[0])
	lon_follower = float(match2[1])

	print("Going to Lat:%s, Long:%s" %(lat, lon))
	text_file.write("%d \t %d" %(lat,lon))

	# Generate leader location
	leader_location = LocationGlobalRelative(lat, lon, HOVER_ALT)
	follower.simple_goto(leader_location)
	time.sleep(UPDATE_TIME)

def land(vehicle):
	vehicle.mode = VehicleMode("RTL")

def set_home(vehicle):
	my_location = vehicle.location.global_frame
	vehicle.home_location = my_location

	# Get Vehicle Home location - will be `None` until first set by autopilot
	while not vehicle.home_location:
	    cmds1 = vehicle.commands
	    cmds1.download()
	    cmds1.wait_ready()
	    if not vehicle.home_location:
	    	print("  Waiting for home location ...")

	# We have a home location.
	print (">>>Home location: %s" %vehicle.home_location)
	time.sleep(3)

# Calling functions to perform follow the leader
set_home(leader)
set_home(follower)
arm(leader, 1)
arm(follower, 2)
takeoff(follower, HOVER_ALT)

# Check for user confirmation to proceed with follow the leader
user_input = raw_input("Press Y to start Follow the Leader mission or N to abort\n>>> ")
if user_input.lower() == "y" or user_input.lower() == "yes":
	print(">>>Proceed in 5 seconds")
	print(">>>Press CONTROL-C to exit mission at any time")
	time.sleep(5)
	try:
		while True:
			follow_the_leader(leader, follower)
	except KeyboardInterrupt:
		# Keyboard interrupt with CONTROL-C
		print("+++++++++++++++++++++++++\n>>>Mission ended\n+++++++++++++++++++++++++")

else:
	print(">>>Aborted")

#Land follower and close vehicles
text_file.close()
leader.close()
follower.close()