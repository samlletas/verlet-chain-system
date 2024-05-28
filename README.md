# Verlet Chain System

Rope/Chain simulation system, ideal for character clothes such as scarfs and capes.

![Screenshot](https://github.com/samlletas/verlet-chain-system/assets/7089504/84ceae0c-fe27-4553-9819-7b65b88cbc03)

## Features

1. Simulation runs at a fixed timestep for consistency (framerate is user-configurable).
1. Optional interpolation toggle for smooth animations.
1. Cloth flowing on wind effect (useful for idle characters).
1. Override system to change parameters on the fly for finer control of animations (e.g. decreasing simulation gravity during a character jump).

## Demo

A demo of the example scene can be downloaded from:
[demo-windows.zip](https://github.com/samlletas/verlet-chain-system/files/15466392/demo-windows.zip)

**Controls:**
- Drag the yellow knob with the mouse.

## Setup

Download or clone the source code and copy/paste the `VerletChainSystem` folder into your `Assets` folder.

## Usage

1. Add the `VerletChain` component to an empty gameobject, this will add a `LineRenderer` component (don't forget to set the color, width and material).

1. (Optional) Add the `VerletWave` component to get a wind-like effect on your rope/chain.

1. (Optional) Create overrides by right clicking on the project view and selecting `Create -> Verlet Chain System -> Verlet Chain Override`. To apply an override simply call the `VerletChainOverride.Apply` function and pass the reference to the chain that you wish to have it's parameters changed:

    ```csharp
    myOverride.Apply(myChain);
    ```
## References

- https://datagenetics.com/blog/july22018/index.html
- https://owlree.blog/posts/simulating-a-rope.html
- https://toqoz.fyi/game-rope.html
- https://stackoverflow.com/questions/42609279/
- https://www.gafferongames.com/post/fix_your_timestep/
