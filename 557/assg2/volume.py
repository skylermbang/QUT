from math import pi

results = []


def calculatecube():

    Cube_Length = float(input('The length of the cube: '))
    Cube_Volume = Cube_Length ** 3
    print('\n The input length of cube : %.1f  and the volume: %.1f' % (
        Cube_Length, Cube_Volume))
    results.append(Cube_Volume)


def calculatepyramid():
    Pyramid_Base = float(input('The base length of the pyramid: '))
    Pyramid_Height = float(input('The height of the pyramid: '))
    Pyramid_Volume = (1 / 3) * (Pyramid_Base ** 2) * Pyramid_Height
    print('\nThe input base length of pyramid : %.1f, the input height length of pyramid: %.1f and the volume: %.1f' % (
        Pyramid_Base, Pyramid_Height, Pyramid_Volume))
    results.append(Pyramid_Volume)


def calculateellipsoid():

    R1_ellipsoid = float(input('The value of radius 1: '))
    R2_ellipsoid = float(input('The value of radius 2: '))
    R3_ellipsoid = float(input('The value of radius 3: '))
    Ellipsoid_volume = (4 / 3) * pi * R1_ellipsoid * \
        R2_ellipsoid * R3_ellipsoid

    print('\nThe 1st radius: %.1f, 2nd radius: %.1f, 3rd radius: %.1f, the volume: %.1f' % (
        R1_ellipsoid, R2_ellipsoid, R3_ellipsoid, Ellipsoid_volume))
    results.append(Ellipsoid_volume)


def print_result():

    results.sort()
    print("All the caluclatedd result shown in ascending order ")
    print(results)
