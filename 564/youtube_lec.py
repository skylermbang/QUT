# banking system using oop
# parent class : user
# holds details about an user
# has a function to show user detail
# childe class: bank
# stores detilas aobut the account balance
# stores details about the amount
# allows for deposits, withdreaw, view_balance


# Parent Class
class User() :
    def __init__(self,name, age,gender):
        self.name = name
        self.age = age
        self.gender = gender


    def show_detail(self):
        print("personal deatils")
        print("")
        print("Name: ", self.name)
        print("Age", self.age)
        print("Gender", self.gender)

Skyler = User("Skyler", 29, "Male")
Skyler.show_detail()

#Child Class

class Bank(User):
    def __init__(self, name,age,gender):
        super().__init__(name,age,gender)
        self.balance = 0

    def deposit(self,amount):
        self.amount = amount
        self.balance = self.balance + self.amount
        print("Account balance has been updated :  $", self.balance)

    def withraw(self, amount):
        self.amount = amount
        if(self.amount > self.balance):
             print(" Insufficient fund. Your balance is " , self.balance)
        else:
            self.balance = self.balance - self.amount
            print("Account balance has been updated : $" , self.balance)

    def show_balance(self):
        self.show_detail()
        print("Account balance has been updated : $", self.balance)





johan = Bank('Johan', 30, 'male')
johan.deposit(200)
johan.withraw(10)
johan.deposit(2000)
johan.withraw(10000)
johan.withraw(440)
johan.show_balance()