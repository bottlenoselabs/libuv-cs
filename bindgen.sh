#!/bin/bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"
echo "Started bindgen... Directory: $DIR"

function exit_if_last_command_failed() {
    error=$?
    if [ $error -ne 0 ]; then
        exit $error
    fi
}

function bindgen {
    c2cs ast -i $DIR/ext/libuv/include/uv.h -o $DIR/ast/uv.json -s $DIR/ext/libuv/include
    exit_if_last_command_failed
    c2cs cs -i $DIR/ast/uv.json -o $DIR/src/uv/uv.cs -l "uv" -c "uv" -g $DIR/ignored.txt
    exit_if_last_command_failed
}

bindgen
