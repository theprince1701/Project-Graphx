# Project Graphx


# Explanations



#Scope 

Reticle Drawing

![c122b4618419d1942aa5bc4565bef5bc](https://user-images.githubusercontent.com/96841021/229958575-80c414e9-9dff-4ef5-a33f-623de0c2ac8b.png)
![34dd4513de9b2d3573a5aca4d941ed5c](https://user-images.githubusercontent.com/96841021/229958602-fcad3c76-4a21-4182-92a4-d275384fc5e1.png)


The base of the scope is made by simply rendering a camera with a low FOV to a scope lens object to act as a magnifying glass for the scope. But were stil missing a critical part of the implementation, the reticle.

First of all, lets look at how real life reticles work. No matter where the gun users eyes are, the reticle is always centered to the middle of the scope. This is to ensure that the reticle is always on target and no matter the offset, you can rely on the reticle to get a clear shot.

Consider the image below.

Red Line: Camera Direction
Black Line: Scope Lens
Green Line: Normal
Blue Line: Offset


![Untitled](https://user-images.githubusercontent.com/96841021/229947023-3d0278b7-6d9a-423c-a56f-ddc6b670371b.png)

What we need to do is find the offset (blue line). To do this we need to add the normal and camera direction together.

![8da99071efbafe1bdf81dab2e64a9558](https://user-images.githubusercontent.com/96841021/229947223-68cb3537-83e9-4a09-8d98-99086ae6693b.png)

First of all, we start by sending the vertex information to the fragment shader. In the fragment shader, we start by recieving the information from the vertex shader.
Like stated earlier, we need to find the offset so we preform a quick addition and store it as a float3 (xyz). To calculate the UV'S, we take the offsets x and y 
because we are only concered about the uv's in 2D because the lens is 2D, we can multiply by some scale to increase/decrease the reticle scale.
Finally, we can return it with a slight offset to center the reticle.



Vignette Drawing

![f6dfbb27cfa12b25cb705fe79b905fa7](https://user-images.githubusercontent.com/96841021/229958414-8acf2aaa-1a7d-4cc8-a624-ca63b21689ad.png)

![f441495b5140a26555bafb946a7a2f59](https://user-images.githubusercontent.com/96841021/229958422-54710d18-fc04-4ac5-9106-1130a4d6336e.png)


![aa251287b25e111fe16bf20fc00d0293](https://user-images.githubusercontent.com/96841021/229947760-0e703dfc-1fc2-4f9f-ad6b-7ee6df869554.png)

We start off the shader very similar to the reticle drawing because we need to know about of the offset for this. Once we find the offset, we can sample the RenderTexture (attached to the Scope Camera) with the uv's calculated from the offset. 

To calculate the Vignette effect we first need to get the positions of the uvs, we can store this in a local variable. Next, we need to get the length of the position vector. After this we can lerp between 1 and 0 based on a smoothstep function between the vignette radius, and vignette radius + vignettesmoothness, with the length of the position as our time). We do the smoothstep because plugging in our length directly will result in the vignette effect being too strong - using a smoothstep function allows us to not only control the intensity of the vignette, but also provide a smoother transition between unfaded/faded.


#Color Grading

#Bloom

#Lens Distortion





