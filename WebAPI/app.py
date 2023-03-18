from flask import Flask, jsonify

app = Flask(__name__)

@app.route('/api/message', methods=['GET'])
def get_message():
    response = {
        "message": "Hello, this is a simple web API created with Flask!"
    }
    return jsonify(response)

if __name__ == '__main__':
    app.run(debug=True)
