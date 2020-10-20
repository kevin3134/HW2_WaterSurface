  
###########################
# WaterSurface project CMakeList
# include GLAD, GLFW, GLM
###########################

cmake_minimum_required(VERSION 3.0)
project(waterwave_sineWave)
project(waterwave_gestnerWave)
project(waterwave_gestnerWaveWithLight)

aux_source_directory(. DIR_TOOT_SRCS)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g")
# add_executable(${PROJECT_NAME} ${DIR_TOOT_SRCS})
include_directories(${PROJECT_SOURCE_DIR}/include)

###########################
# GLAD
###########################
# include_directories("glad")
add_executable(waterwave_sineWave
    src/sineWaveSimulate.cpp 
    src/glad.c
    src/Wave.h
    src/Wave.cpp
    include/Shader.h
    include/Camera.h
)

add_executable(waterwave_gestnerWave
    src/gestnerWaveSimulate.cpp 
    src/glad.c
    src/Wave.h
    src/Wave.cpp
    src/Skybox.h
    src/Skybox.cpp
    include/Shader.h
    include/Camera.h
)

add_executable(waterwave_gestnerWaveWithLight
    src/gestnerWaveSimulateWithLight.cpp 
    src/glad.c
    src/Wave.h
    src/Wave.cpp
    src/Skybox.h
    src/Skybox.cpp
    include/Shader.h
    include/Camera.h
)


###########################
# GLFW
###########################
set(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)

if(WIN32)
    message(STATUS "starting configure glfw win32")
    add_subdirectory(glfw)
    include_directories(glfw/include)
    target_link_libraries(waterwave_sineWave glfw ${GLFW_LIBRARIES})
    target_link_libraries(waterwave_gestnerWave glfw ${GLFW_LIBRARIES})
    target_link_libraries(waterwave_gestnerWaveWithLight glfw ${GLFW_LIBRARIES})
endif()

###########################
# GLM
###########################
if(WIN32)
    message(STATUS "starting configure glm win32")
    add_subdirectory(glm)
    include_directories(glm/include)
    target_link_libraries(waterwave_sineWave glm ${GLM_LIBRARIES})
    target_link_libraries(waterwave_gestnerWave glm ${GLFW_LIBRARIES})
    target_link_libraries(waterwave_gestnerWaveWithLight glm ${GLFW_LIBRARIES})
endif()

##########################
# OPENGL
##########################
find_package(OpenGL REQUIRED)




