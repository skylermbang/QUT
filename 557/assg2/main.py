from volume import calculatecube
from volume import calculateellipsoid
from volume import calculatepyramid
from volume import *
from math import pi


def main():
    Userinput = (input(
        'Type "C" for the cube volume, type "P" for the pyramid volume, type "E" for the ellipsoid volume, type "quit" to quit: ')).upper()
    # asking user input variable C/P/E/quit
    # Creation of validity loop

    valid = False
    while not valid:  # staring while loop to check the user's input variable.
        if Userinput == 'C':  # if it is c
            calculatecube()  # calling function cubeVolume
            print()
            Userinput = (input(
                'Type "C" for the cube volume, type "P" for the pyramid volume, type "E" for the ellipsoid volume, type "quit" to quit: ')).upper()
        elif Userinput == 'P':
            calculatepyramid()
            print()
            Userinput = (input(
                'Type "C" for the cube volume, type "P" for the pyramid volume, type "E" for the ellipsoid volume, type "quit" to quit: ')).upper()
        elif Userinput == 'E':
            calculateellipsoid()
            print()
            Userinput = (input(
                'Type "C" for the cube volume, type "P" for the pyramid volume, type "E" for the ellipsoid volume, type "quit" to quit: ')).upper()
        elif Userinput == 'QUIT':
            valid = True
            print_result()
        else:
            print('\nInvalid input! Please try again.')
            print()
            Userinput = (input(
                'Type "C" for the cube volume, type "P" for the pyramid volume, type "E" for the ellipsoid volume, type "quit" to quit: ')).upper()

    # Output after user enters "quit"


main()  # Calling the main function
