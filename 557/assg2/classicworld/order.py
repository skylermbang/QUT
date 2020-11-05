from datetime import datetime
from .catg import Catg
from .product import Product


class Order:
    def __init__(self, status, firstname, surname, email, phone, date, products, total_cost):
        self.status = status
        self.firstname = firstname
        self.surname = surname
        self.email = email
        self.phone = phone
        self.date = date
        self.products = products
        self.total_cost = total_cost

    def get_tour_details(self):
        return str(self)

    def __repr__(self):
        str = "Status: {}, Firstname: {}, Surname: {}, Email: {}, Phone: {}, Date: {}, product:s {}, Total Cost: {}\n"
        str = str.format(self.status, self.firstname, self.surname,
                         self.email, self.phone, self.date, self.products, self.total_cost)
        return str
