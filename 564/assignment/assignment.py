class Car:
    def __init__(self, maker, model):
        self.maker = maker
        self.model = model

    def show(self):
        print("Model :", self.model, " from ",  self.maker)


first_car = Car("Honda", "CR-V")
first_car.show()
