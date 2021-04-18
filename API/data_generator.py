from random import randint, uniform
import threading
raw_data = dict()


def generator():
    global raw_data

    while True:
        pulse_frequency = randint(5, 10)  # Импулсь [Гц]
        reactor_inlet_temperature = randint(25, 60)  # Температура на входе в реактор [\u00b0C]
        reactor_outlet_temperature = randint(25, 95)  # Температура на выходе в реактор [\u00b0C]
        coolant_pressure = round(uniform(4.0, 5.0), 2)  # Давление теплоносителя [Па]

        raw_data = {'pulse_frequency': pulse_frequency,
                    'reactor_inlet_temperature': reactor_inlet_temperature,
                    'reactor_outlet_temperature': reactor_outlet_temperature,
                    'coolant_pressure': coolant_pressure
                    }
        e1.wait(0.5)


def get_raw_data():
    return raw_data


e1 = threading.Event()
t1 = threading.Thread(target=generator)
t1.start()
