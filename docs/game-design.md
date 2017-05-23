1969
====

This is a simple strategy game centered around base building. The closest
prototype is Jack Whitham's [20,000 Light Years Into Space][20kly] (the project
is open-source but the development has been stalled).

Game field
----------

Game field should be small enough to fit on the screen. Each level is a segment
of Mars space. Game field contains various objects.

![Concept image][concept]

- **Base**: this is your HQ. Your goal is to deliver some quantity of resources
  there. **Base** could be upgraded using resources. Requires fixed amount of
  power.
- **Builder**: base could produce these. They move around **Base** or around
  **Power Lines** and build stuff (including new **Power Nodes** and
  **Power Lines**). Also terraforms **Rough Terrain**. Requires power to move
  and to build stuff.
- **Resource Gatherer**: an automated mining facility. Gathers resources, sends
  them back to the base using **Power Lines**.
- **Power Lines** and **Power Nodes**: created by **Builders**, helps to
  transfer resources around; required for **Builder** bo move.
- **Resource Nodes**: infinite sources of power.
- **Rough Terrain**: **Builders** can't pass this until it's terraformed.

Game Goal
---------

Goal of every (basic) level is to reach some level of the base and to reach some
fixed power production level.

[20kly]: https://www.jwhitham.org/20kly/

[concept]: https://github.com/ForNeVeR/1969/blob/master/1-game-design/docs/concept.svg
