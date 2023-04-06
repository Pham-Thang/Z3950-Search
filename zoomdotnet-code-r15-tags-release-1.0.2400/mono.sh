#!/bin/sh
# setting up environmental stuff for libs not found inside GAC
export MONO_PATH=".:`pwd`:/usr/lib/NAnt/lib/mono/1.0:/usr/lib/nunit:/usr/lib/cli/nunit-2.2.6"
# bad hack needed to get fingers on nant internals !!
export PATH="$PATH:$MONO_PATH"
