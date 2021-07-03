

#  564 week 11 tutorial ;
# part 4 from the workshop material
#  clinet class
class Bike:
  def __init__(self, number, status, order):
    self.number = number
    self.status = 1   #   1 = bike currently available,  2 = bike not availble
    self.order = order


class Clinet:
  def __init__(self, name, sataus, bikeNumber):
    self.name = name
    self.status= 2    #    1 = currently renting ,  2 = not renting
    self.bikeNumber = 0





bike1 = Bike(1,1,1)
client1 = Clinet(1,2)
