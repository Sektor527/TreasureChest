cmake_minimum_required(VERSION 2.6)
project(TreasureChest)

# Define source files
set(core_dir ${PROJECT_SOURCE_DIR}/src/core)

set(core_sources
)

# Build core library
include_directories(${PROJECT_SOURCE_DIR}/src/core)
add_library(core ${core_sources})

# Build and run unit tests
add_subdirectory(tests)
