project (tests)

# Define source files
set(testfiles
	ConsumerTests.cpp
	InventoryTests.cpp
)

# Set gtest/gmock environment
set(GMOCK_DIR ${PROJECT_SOURCE_DIR}/../dependencies/gmock)
set(GTEST_DIR ${PROJECT_SOURCE_DIR}/../dependencies/gmock/gtest)
set(GMOCK_INCLUDE_DIR ${GMOCK_DIR}/include)
set(GTEST_INCLUDE_DIR ${GTEST_DIR}/include)

include_directories(${GMOCK_DIR} ${GTEST_DIR} ${GMOCK_INCLUDE_DIR} ${GTEST_INCLUDE_DIR} ${PROJECT_SOURCE_DIR}/../src)

# Build tests
add_executable(tests 
	main.cpp
	${testfiles}
	${core_sources}
	${GMOCK_DIR}/src/gmock-all.cc
	${GMOCK_DIR}/gtest/src/gtest-all.cc
)

add_custom_command(TARGET tests POST_BUILD COMMAND tests)
