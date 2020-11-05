from flask import Flask


def create_app():
    app-Flask(__name_)
    app.debug = True

    # add the Blueprint
    from . import views
    app.register_blueprint(views.bp)

    return app
