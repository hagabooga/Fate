from enum import Enum, auto
import itertools


class Stats(Enum):
    Wisdom = auto()
    Perception = auto()
    Charisma = auto()
    Vitality = auto()
    Fortitude = auto()
    Strength = auto()
    Dexterity = auto()
    Luck = auto()


count = 0
for x in itertools.combinations(Stats._member_names_, 7):
    print(" + ".join(x))
    count += 1

print(count)
