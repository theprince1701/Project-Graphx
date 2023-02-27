# Project Graphx
Part 1: Base
- [X] Individual assignment integration
- [X] Flowcharts
- [X] Modifications

Part 2: Shadows
- [X] Shadow Shader
- [X] Scene implementation

Part 3: Visual effects
- [X] Muzzle Flash
- [X] Walk effect
- [X] Trail effect
- [X] Hit Impact
- [X] Bullet Tracer
- [X] Lens Flare

Part 4: Post Processing
- [X] Bloom
- [X] Outline
- [X] Depth of Field

Part 5: Report
- [X] Video
- [X] Google slides
- [X] Statement of Contribution(In Slides)
 
Unlisted Youtube Playlist of presentation and Demo video: https://www.youtube.com/playlist?list=PL0o7UHm4zj_QA1S1gM6w9wwrfNZBLkbJs

This game is a first iteration of projct Graphx and includes the tower defense aspect of the game with several shaders and working gameplay.

The player can can win by running down the timer while making sure that no enemies touch the tower more than 3 times, which will trigger the loss condition. The player can kill the enemies using the provided gun.

The project includes all shaders from the previous individual assignment and 3 post processing effects, multiple visual effects and a shadow shader.

Shadow Shader:

The shadow shader has two passes: one to render the object, and another to render the shadows.

The first pass uses the ForwardBase Unity lighting mode to calculate the shadow colour by multiplying the object’s diffuse colour with the attenuation of the shadow map. The second pass uses the Shadow Caster lighting mode to calculate the depth and information of the shadows.

Vert transforms the object’s vertices to the worldspace and calculates the light intensity based on the object’s normal and direction of the light source.
The frag function calculates the final colour of each pixel using the colour and texture of the object  as well as the previously calculated shadow map and colour.

Visual effects:

The visual effects were made through Unity's particle system with the exception of the lens flare which uses Unity's lens flare system.

Outline:

Similar to the shadow shader, the shader for the outline effect uses 2 passes. It starts off with a standard Lambert shader and defines the surface properties in the first pass.

The second pass renders the actual outline effect by using the cull command to render only the front facing polygons of the object.
While the object’s colour is defined by the diffuse colour of the object, the outline’s colour is user defined.

Bloom:

The bloom shader works using four pass blocks, as well as two structs.

The first one applies the bloom effect by changing the colour of the object using a sample box and pre filter functions.

The second pass samples the MainTex and returns the colour value.

The third pass combines the original colour with the bloom effect.

The fourth and final pass applies the effect to the entire screen and returns the value of the bloom effect

An additional script applies the effect onto the camera.

Depth of Field:

The first pass computes the Circle of Confusion for each pixel based on the object's distance from the camera as a measure of blur size.

The second pass samples the CoC texture to determine the average blur for a group of pixels, which is outputted as a texture.

The third pass applies a blur to the image based on the previously mentioned CoC texture. 

The fourth and final pass applies a final sharpening filter to the blurred image.

An additional script applies it to the main camera.

Link to slides: https://docs.google.com/presentation/d/1JoOLTO40zQcRtqCMEZNQVyOqe5HlMJ7PpHh0b7y8SEk/edit?usp=sharing












