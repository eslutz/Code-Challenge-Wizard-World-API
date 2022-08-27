# Code Challenge: Wizard World API

This challenge will test your ability to make calls to an API, as well as your ability to process that data to get the needed information.  You will be making calls to the Harry Potter Wizard World API and using the returned data to answer some questions.  Refer to the [Wizard World API](https://github.com/MossPiglets/WizardWorldAPI) documentation on GitHub and the API [Swagger](https://wizard-world-api.herokuapp.com/swagger/index.html) page to determine how to call the different endpoints.

## How to Start the Challenge

1. Fork this project to your account ([Forking a repository](https://docs.github.com/en/get-started/quickstart/fork-a-repo#forking-a-repository))
1. Clone the forked repo to your computer ([Cloning a repository](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository#cloning-a-repository))
1. Start a new project, in a language of your choosing, in the cloned repo
1. Complete the requirements listed in [Requirements](#requirements)
1. Validate your program against the values in [Validation](#validation)

## Join in on the discussion in our [Discord code-challenge](https://discord.com/channels/966813541569003581/1004198114917371964) channel!
- Share your solution
- Ask questions
- Check out the solutions others have come up with
- Provide feedback on the code challenge itself

## Requirements

Write a program that answers the following questions:

- From the different characters, what are the top 3 most common elixirs?
  - For each of the top three, how many wizards have that elixir?
- What are the side effects of the top elixir?
- What other elixirs share any ingredient with the top elixir?
- What are the different types of spells?
  - How many of each type of spell are there?

## Validation

*Sample Output With Correct Answers*

```
Top Three Elixirs
*****************
1. 3 wizards have the elixir "Love potion".
2. 2 wizards have the elixir "First Love Beguiling Bubbles".
3. 2 wizards have the elixir "Heartbreak Teardrops".

The top elixir "Love potion" has the side effect of "Embarrassment on the part of the drinker".

Elixirs That Share an Ingredient With "Love potion"
****************************************************
1.  Beautification Potion
2.  First Love Beguiling Bubbles
3.  Heartbreak Teardrops
4.  Twilight Moonbeams
5.  Amortentia
6.  Cupid Crystals
7.  Kissing Concoction
8.  Calming Draught
9.  Invigoration Draught
10. Elixir to Induce Euphoria
11. Felix Felicis
12. Draught of Peace
13. Potion N. 86

Spell Types and Number of Spells With That Type
************************************************
1.  Charm                          x 160
2.  Conjuration                    x 13
3.  Transfiguration                x 30
4.  DarkCharm                      x 13
5.  Spell                          x 4
6.  HealingSpell                   x 7
7.  Jinx                           x 26
8.  Curse                          x 23
9.  MagicalTransportation          x 3
10. Hex                            x 17
11. CounterSpell                   x 1
12. DarkArts                       x 2
13. CounterJinx                    x 1
14. CounterCharm                   x 2
15. None                           x 1
16. Untransfiguration              x 1
17. BindingMagicalContract         x 1
18. Vanishment                     x 1
```
<br/>

***

### References

MossPiglets (2021) WizardWorldAPI (v1.0.1) [Source Code]. https://github.com/MossPiglets/WizardWorldAPI

MossPiglets. (2021). WizardWorldAPI Swagger. https://wizard-world-api.herokuapp.com/swagger/index.html