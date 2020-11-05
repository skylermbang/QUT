from datetime import datetime
from classicworld.catg import Catg
from classicworld.order import Order
from classicworld.product import Product


print('Creating a Catagory American muscle')
AmericanMuscle = Catg(
    'AmericanMuscle', '60s American Muscle')
print(AmericanMuscle)
print('#################')

print('Creating a new vechicle in American Msucle')

Mustang = Product('Mustang', 'Ford',
                  '1969', "The best mustang", "skyler", 50000)
print(Mustang)
print('#################')

print('Creating another new vechicle for American Msucle')

Camaro = Product('Camaro', 'Chevorlet',
                 '1967', "Betteer than Mustang", "skyler", 37000)
print(Camaro)
print('#################')

print('Creating a new order')
order = Order(False, 'Jane', 'Smith', 'jsmith@gmail.com', '0402 111 222',
              datetime.now(), Mustang, Mustang.price)
print(order)
