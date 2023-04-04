# Project Graphx


# Explanations

Scope Shader

The base of the scope is made by simply rendering a camera with a low FOV to a scope lens object to act as a magnifying glass for the scope. But were stil missing a critical part of the implementation, the reticle.

First of all, lets look at how real life reticles work. No matter where the gun users eyes are, the reticle is always centered to the middle of the scope. This is to ensure that the reticle is always on target and no matter the offset, you can rely on the reticle to get a clear shot.

The magic happens in the fragment shader, where it takes in the transformed vertex data and calculates the normal and tangent vectors at the current fragment. It then calculates the direction to the eye space origin and adds it to the normal vector to get an offset vector. The offset vector is transformed into tangent space using a 3x3 matrix formed by the tangent, the cross product of the normal and tangent, and the normal vectors. The resulting offset is used to sample the texture at the current fragment, and the color of the texture is returned as the output color of the shader.






