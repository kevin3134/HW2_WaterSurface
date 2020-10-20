#version 330 core

in VS_OUT {
    vec4 fragPos;
    vec3 normal;
} fs_in;

out vec4 fragColor;

uniform vec3 viewPos;
uniform vec3 deepWaterColor;
uniform vec3 shallowWaterColor;
uniform samplerCube skybox;

void main()
{
    vec3 eyeVec = normalize(viewPos - vec3(fs_in.fragPos));
    //float facing = clamp(dot(eyeVec, normalize(fs_in.normal)), 0.0, 1.0);

    vec3 reflectVec = reflect(eyeVec, normalize(fs_in.normal));
    //fragColor = texture(skybox, refVec);
    //fragColor = vec4(mix(shallowWaterColor, deepWaterColor, facing), 1.0);
    //fragColor = mix(vec4(deepWaterColor, 1.0), texture(skybox, refVec), facing);
    //fragColor = mix(vec4(deepWaterColor, 1.0), texture(skybox, refVec), facing);

    //consider fresnel effect

    float thetaI = acos(dot(eyeVec, fs_in.normal));
    float thetaT = asin(0.75 * sin(thetaI));

    float reflectivity;
    if (abs(thetaI) >= 0.000001) {
        float t1 = sin(thetaT - thetaI), t2 = sin(thetaT + thetaI);
        float t3 = tan(thetaT - thetaI), t4 = tan(thetaT + thetaI);
        reflectivity = 0.5 * (t1*t1/(t2*t2) + t3*t3/(t4*t4));
        if (reflectivity > 1.0) reflectivity = 1.0;
    } else {
        reflectivity = 0;
    }

    // Reflection color component
    float balanceColor = 0.4;
    vec4 r = texture(skybox, reflectVec) + vec4(deepWaterColor, 0.0f);
    //vec4 r = texture(skybox, reflectVec);


    // Transmission color component
    vec4 t = vec4(deepWaterColor, 1.0);

    // Calculate Fresnel Reflection and Refraction
    fragColor = reflectivity * r + (1 - reflectivity) * t;

} 