from datetime import datetime
from .city import City


class Tour:
    def __init__(self, name, description, image, price, city, date):
        self.name = name
        self.description = description
        self.image = image
        self.price = price
        self.city = city
        self.date = date

    def get_tour_details(self):
        return str(self)

    def __repr__(self):
        str = "Name: {}, Description: {}, Image: {}, Price: {}, City: {}, Date: {}\n"
        str = str.format(self.name, self.description,
                         self.image, self.price, self.city, self.date)
        return str
