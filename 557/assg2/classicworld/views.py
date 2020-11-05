
from flask import Blueprint, render_template, url_for, request, session, flash, redirect
from .models import Catg, Product, Order
from datetime import datetime
from .forms import CheckoutForm
from . import db

bp = Blueprint('main', __name__)


@bp.route('/')
def index():
    catgs = Catg.query.order_by(Catg.name).all()
    # catgs = Catg.query.all()
    print(catgs)
    return render_template('index.html', catgs=catgs)


@bp.route('/products/<int:category_id>/')
def catgproducts(category_id):
    catgproducts = Product.query.filter(Product.catg_id == category_id)
    print(" ########TES1  ######")
    print(category_id)
    print(" ########TEST2 ######")

    print(" ######## END TEST  ######")

    return render_template('catgproduct.html', products=catgproducts)


#############################

@bp.route('/details/<int:product_id>/')
def productdetail(product_id):
    #product_id = request.values.get('product_id')
    details = Product.query.get(product_id)
    print("####test###")
    print(details)
    print(product_id)
    return render_template('productspec.html', product=details)


# Referred to as "Basket" to the user


@bp.route('/order', methods=['POST', 'GET'])
def order():
    product_id = request.values.get('product_id')

    # retrieve order if there is one
    if 'order_id' in session.keys():
        order = Order.query.get(session['order_id'])
        # order will be None if order_id stale
        print("#you have passed #")
    else:
        # there is no order
        order = None
        print("#ERROR here line45 ###")

    # create new order if needed
    if order is None:
        order = Order(status=False, firstname='', surname='',
                      email='', phone='', totalcost=0, date=datetime.now())
        try:
            db.session.add(order)
            db.session.commit()
            session['order_id'] = order.id
        except:
            print('failed at creating a new order')
            order = None

    # calcultate totalprice
    totalprice = 0
    if order is not None:
        for product in order.products:
            totalprice = totalprice + product.price

    # are we adding an item?
    if product_id is not None and order is not None:
        product = Product.query.get(product_id)
        if product not in order.products:
            try:
                order.products.append(product)
                db.session.commit()
            except:
                return 'There was an issue adding the item to your basket'
            return redirect(url_for('main.order'))
        else:
            flash('item already in basket')
            return redirect(url_for('main.order'))

    return render_template('order.html', order=order, totalprice=totalprice)


@bp.route('/deleteorderitem', methods=['POST'])
def deleteorderitem():
    id = request.form['id']
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])
        deleting_product = Product.query.get(id)

        try:
            order.products.remove(deleting_product)
            db.session.commit()
            return redirect(url_for('main.order'))
        except:
            return 'Problem deleting item from order'
    return redirect(url_for('main.order'))


# Scrap basket
@bp.route('/deleteorder')
def deleteorder():
    if 'order_id' in session:
        del session['order_id']
        flash('All items deleted')
    return redirect(url_for('main.index'))


@bp.route('/checkout', methods=['POST', 'GET'])
def checkout():
    form = CheckoutForm()
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])

        if form.validate_on_submit():
            order.status = True
            order.firstname = form.firstname.data
            order.surname = form.surname.data
            order.email = form.email.data
            order.phone = form.phone.data
            totalcost = 0
            for product in order.products:
                totalcost = totalcost + product.price
            order.totalcost = totalcost
            order.date = datetime.now()
            try:
                db.session.commit()
                del session['order_id']
                flash(
                    'Thank you! One of our awesome team members will contact you soon...')
                return redirect(url_for('main.index'))
            except:
                return 'There was an issue completing your order'
    return render_template('checkout.html', form=form)


'''
@bp.route('/tours/<int:cityid>/')
def citytours(cityid):
    tours = Tour.query.filter(Tour.city_id == cityid)
    # print(Tour.query.filter(Tour.city_id == 2))
    return render_template('citytours.html', tours=tours)

@bp.route('/products/<int:category_id>/')
def catgproducts(category_id):
    catgproducts = []
    # create list of products for this city
    for product in products:
        if product.catg.id == category_id:
            catgproducts.append(product)
    return render_template('catgproduct.html', products=catgproducts)


# STUBS for routes not implemented yet
# (get_url links in the templates will fail without these routes defined)


@ bp.route('/order/', methods=['POST', 'GET'])
def order():
    # return render_template('order.html', order = order, totalprice = order.total_cost)
    return 'not implemented yet'


@ bp.route('/deleteorder/')
def deleteorder():
    # return render_template('index.html')
    return 'not implemented yet'


@ bp.route('/deleteorderitem/', methods=['POST'])
def deleteorderitem():
    # return render_template('index.html')
    return 'not implemented yet'


@ bp.route('/checkout/', methods=['POST', 'GET'])
def checkout():
    # return render_template('checkout.html', form = form)
    return 'not implemented yet'
'''
