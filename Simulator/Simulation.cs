﻿using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int _currentTurnIndex = 0;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentTurnIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentTurnIndex % Moves.Length].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Creature's list is empty.");
        }
        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures is different from number of sstarting positions.");
        }
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }
            creature.InitMapAndPosition(map, position);

            map.Add(creature, position);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Moves.Length == 0)
        {
            Finished = true;
        }

        if (Finished)
        {
            throw new ArgumentException("Simulation finished.");
        }

        List<Direction> parsedDirections = DirectionParser.Parse(CurrentMoveName);
        if (parsedDirections.Count == 0)
        {
            _currentTurnIndex++;
            return;
        }
        Direction direction = parsedDirections[0];
        Creature currentCreature = CurrentCreature;
        Point oldPosition = currentCreature.Position;
        Point newPosition = Map.Next(oldPosition, direction);
        if (Map.Exist(newPosition))
        {
            Map.Move(currentCreature, oldPosition, newPosition);
            currentCreature.Go(direction);
        }
        _currentTurnIndex++;
        if (_currentTurnIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}
