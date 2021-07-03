# Linked list for bike that is avaialbe

class Node:
    def __init__(self, bikeNumber, ):
        self.bikeNumber = bikeNumber
        self.next =None


class BikeLinkedList:
    def __init__(self):
        self.head = None

    def showbike(self):
        printval = self.head
        while printval is not None:
            print(printval.bikeNumber)
            printval = printval.next

    def addAvailableBike(self, bikeNumber):
        BikeM = self.head
        while (BikeM.next):
            BikeM = BikeM.next
        addedNode =Node(bikeNumber)
        BikeM.next =addedNode

    def removeBike(self, Rdata):
            HeadVal = self.head
            if (HeadVal is not None):
                if (HeadVal.bikeNumber == Rdata):
                    self.head = HeadVal.next
                    HeadVal = None
                    return
            while (HeadVal is not None):
                if HeadVal.bikeNumber == Rdata:
                    break
                prev = HeadVal
                HeadVal = HeadVal.next
            if (HeadVal == None):
                return
            prev.next = HeadVal.next
            HeadVal = None


bike = BikeLinkedList() # initializing
bike.head = Node("Bike1")
bike2 = Node("Bike2")
bike3 = Node("Bike3")
bike.head.next = bike2
bike2.next =bike3
bike.addAvailableBike("Bike10")
bike.removeBike("Bike3")
bike.showbike()
