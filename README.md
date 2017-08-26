# Arcade Space Flight Physics Example
Simple example of arcade style space sim flight physics. Built with Unity 5.6.

![screenshot](http://i.imgur.com/vQEt6Jd.png)

## Download

You can either clone the repository, or [download either the demo or asset package from the releases page](https://github.com/brihernandez/ArcadeSpaceFlightExample/releases).

## Controls

There are two control modes supported. The first is **mouse flight** and the second is **traditional**. They can be toggled by checking the "Use Mouse Input" property on the ShipInput component.

### Mouse Controls
- W/S: Increase/Decrease throttle
- A/D: Strafe Left/Right
- Mouse scrollwheel: Increase/Decrease throttle
- Mouse motion: Pitch/Yaw

### Traditional Controls
- W/S: Pitch Down/Up
- A/D: Yaw Left/Right
- R/T: Increase/Decrease throttle

Note that with the traditional control setting, a gamepad or joystick's X/Y axes can be used for flight as well.

## Component Organization

When possible, I like to break things off into very self-contained components. This isn't always possible, but I feel it's a good practice in general that keeps your source files small and easily understood. However, this does add some complexity in that it requires you to link components together in some way.

Personally, I prefer doing these associations in code, especially when the components are likely to be on the same GameObject. In the case of the ship, it's made of three different components: Ship, Input, and Physics. The way I configured it here, the Ship component is meant to represent the entire ship. All external access to ship properties such as velocity or input are meant to go through the ship. In an effort to keep individual components as dumb as possible, and to minimize cross-component dependency, they communicate (only if necessary) to the ship, rather than other components directly. While there isn't an example of this in the project, each component has a reference to the ship just in case. The ship itself also passes information between components as needed.

There are advantages and disadvantages to this method, but I think it's worth showing as an example of one way to tackle complex component interaction.

## Ship

As mentioned above, the ship component represents the ship as a whole and provides a communication mechanism between components.

## Ship Input

In keeping with the mentality of separating out responsibilities, this component handles all input. In this example, only player input is considered, but it would be trivial to add a flag here to ignore player input if this isn't the player (by checking ship.isPlayer). A great use case for this would be if you want an AI to instead drive the input. Having an input layer between the player/AI, and the ship itself, allows the ship to only care about ship input and not where it's coming from.

## Ship Physics

This component is taken almost verbatim from my [UnityCommon repository](https://github.com/brihernandez/UnityCommon). It's a generic space physics component that can apply forces and torques to a rigidbody using inputs that a ship's input would give. You give it the forces that it can apply in each axis, and then how much of those forces to apply.

## Changelog

### 1.0 08/24/2017
- Initial commit