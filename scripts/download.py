#!/usr/bin/env python3

import sys, os
import urllib.request
from shutil import copyfile

arc = ['mac', 'win', 'lin']

if len(sys.argv) != 2:
	print ('Usage: ', __file__, '|'.join(arc))
	exit(1)

if sys.argv[1] not in arc:
	print('Unsupporter architecture: ', sys.argv[1])
	print ('Usage: ', __file__, '|'.join(arc))
	exit(1)

baseUrl = 'https://github.com/MonoGame/MonoGame.Dependencies/raw/master/SDL'
debugPath = os.path.join(os.path.dirname(os.path.abspath(__file__)), '../MarsBaseBuilder/bin/Debug/')
releasePath = os.path.join(os.path.dirname(os.path.abspath(__file__)), '../MarsBaseBuilder/bin/Release/')

if sys.maxsize > 2**32:
	bits = 'x64'
else:
	bits = 'x32'

if sys.argv[1] == 'mac':
	file = 'libSDL2-2.0.0.dylib'
	cur = baseUrl+'/MacOS/Universal/'+bits+'/' + file
	
if sys.argv[1] == 'win':
	file = 'SDL2.dll'
	cur = baseUrl+'/Windows/'+bits+'/' + file
	
if sys.argv[1] == 'lin':
	file = 'libSDL2-2.0.so.0'
	cur = baseUrl+'/Linux/'+bits+'/' + file

print('Downloading...')

urllib.request.urlretrieve(cur, debugPath+file)
try:
	copyfile(debugPath+file, releasePath+file)
except FileNotFoundError:
	pass

print('Done!')