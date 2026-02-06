using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureGenerator : MonoBehaviour
{
    public List<Creature> creatures;
    public Creature creaturePrefab;

    public Sprite[] sprites;

    // tweak these curves in the inspector
    public AnimationCurve youngAgeWeight = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public AnimationCurve hazardToSizeWeight = AnimationCurve.Linear(0, 0, 1, 1);

    public void Start()
    {
        creatures.Add(GenerateCreature());
    }

    int WeightedRandom(int min, int max, AnimationCurve weightCurve)
    {
        float t = weightCurve.Evaluate(Random.value);
        return Mathf.RoundToInt(Mathf.Lerp(min, max, t));
    }

    T WeightedPick<T>(Dictionary<T, float> weights)
    {
        float total = 0f;
        foreach (var w in weights.Values)
            total += w;

        float roll = Random.value * total;

        foreach (var pair in weights)
        {
            if (roll < pair.Value)
                return pair.Key;
            roll -= pair.Value;
        }

        return default;
    }

    string GenerateName(Creature creature)
    {
        string[] prefixes = { "Zar", "Kra", "Vel", "Mor", "Xen" };
        string[] suffixes = { "ix", "on", "ara", "ul", "eth" };

        return prefixes[Random.Range(0, prefixes.Length)]
             + suffixes[Random.Range(0, suffixes.Length)];
    }

    Creature.Rarity GetRarity(Creature.Size size, int hazard)
    {
        float hazardFactor = hazard / 100f;

        var weights = new Dictionary<Creature.Rarity, float>
    {
        { Creature.Rarity.common, 1.5f },
        { Creature.Rarity.uncommon, 1.0f },
        { Creature.Rarity.epic, 0.4f },
        { Creature.Rarity.legendary, 0.1f }
    };

        // size bias
        if (size == Creature.Size.large)
        {
            weights[Creature.Rarity.common] *= 0.5f;
            weights[Creature.Rarity.legendary] *= 2.0f;
        }

        // hazard bias
        weights[Creature.Rarity.epic] += hazardFactor;
        weights[Creature.Rarity.legendary] += hazardFactor * 0.5f;

        return WeightedPick(weights);
    }

    Creature.BreedingType GetBreedingType(Creature.Size size)
    {
        var weights = new Dictionary<Creature.BreedingType, float>
    {
        { Creature.BreedingType.asexual, 1.0f },
        { Creature.BreedingType.mitosis, size == Creature.Size.small ? 1.2f : 0.5f },
        { Creature.BreedingType.sexual, size == Creature.Size.large ? 1.5f : 0.8f }
    };

        return WeightedPick(weights);
    }

    Creature.Size GetSizeFromHazard(int hazard)
    {
        // assuming hazard is 0–100
        float h = hazard / 100f;

        var weights = new Dictionary<Creature.Size, float>
    {
        { Creature.Size.small, 1.5f - h },
        { Creature.Size.medium, 1.0f },
        { Creature.Size.large, h }
    };

        return WeightedPick(weights);
    }

    public Creature GenerateCreature()
    {
        PlanetData planet = GameManager.Instance.selectedPlanet;
        int hazard = planet.AntiMatterHazardLevel;

        Creature creature = new Creature();

        creature.Age = WeightedRandom(0, 670, youngAgeWeight);
        creature.size = GetSizeFromHazard(hazard);
        creature.rarity = GetRarity(creature.size, hazard);
        creature.breedingType = GetBreedingType(creature.size);
        creature.home = planet;
        creature.creatureName = GenerateName(creature);
        creature.sprite = sprites[Random.Range(0, sprites.Length)];

        return creature;
    }
}
