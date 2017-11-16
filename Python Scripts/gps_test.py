# Import DroneKit-Python
from __future__ import print_function
from dronekit import connect, VehicleMode
import dronekit_sitl
import time
import argparse
import math
import re

# Tests GPS accuracy.
parser = argparse.ArgumentParser(description="Gets two vehicle connection strings")
parser.add_argument('--vehic_1', help="Vehicle 1 connection string")
parser.add_argument('--vehic_2', help="Vehicle 2 connection string")
parser.add_argument('--target_acc', help="Target distance between the two vehicles in meters")

args = parser.parse_args()
if not args.target_acc:
    t_acc = "DEFAULT_T_DISTANCE"
else:
    t_acc = args.target_acc
file = open("GPS_accuracy.txt", 'w')
file.write("Intended Distance Apart (m): {}\n".format(t_acc))

sitl_1 = dronekit_sitl.start_default()
sitl_2 = dronekit_sitl.start_default()

conn_str_1 = args.vehic_1
conn_str_2 = args.vehic_2

v_type_1 = ''
v_type_2 = ''

if conn_str_1 and conn_str_2:
    connection_string_1 = conn_str_1
    v_type_1 = "Vehicle"
    connection_string_2 = conn_str_2
    v_type_2 = "Vehicle"
else:
    # Connecting SITL runs into issues, needs more testing
    connection_string_1, connection_string_2 = sitl_1.connection_string(), "tcp:127.0.0.1:5762" 
    print(connection_string_1 + "\n")
    v_type_1 = v_type_2 = "SITL"
    print(connection_string_2 + "\n")
    
# Connect to Vehicle 1.

print("Connecting to {} 1 on: {}\n".format(v_type_1, connection_string_1,))
vehic_1 = connect(connection_string_1, wait_ready=False)
print("done")

# Connect to Vehicle 2
print("Connecting to {} 2 on: {}\n".format(v_type_2, connection_string_2,))
vehic_2 = connect(connection_string_2, wait_ready=False)
print("done")

try: # Prints to console and writes to file position data
    while True:
        location_list_raw = [str(vehic_1.location.global_frame), str(vehic_2.location.global_frame)]
        location_list = []
        regex = r"(-?\d+\.\d+)" 
        for loc in location_list_raw:  
            match = re.findall(regex, loc) # This produces an empty list occasionally when using SITL vehicles. Low priority fix
            location_list += [float(match[0]), float(match[1])]
        diff = abs(math.sqrt((location_list[0] - location_list[2])**2 - (location_list[1] - location_list[3])**2))
        print("Writing :: Pos_1: {}\t Pos_2: {}\n Diff: {}".format(vehic_1.location.global_frame, vehic_2.location.global_frame, diff))
        file.write("Pos_1: {}\t Pos_2: {}\n Diff: {}".format(vehic_1.location.global_frame, vehic_2.location.global_frame, diff))
        time.sleep(1)
except KeyboardInterrupt:
    print("Done writing")

# Close vehicle object before exiting script
vehic_1.close()
vehic_2.close()
