# Starting up repository for NATS Demonstration

11/17
The initial goal of the first four python files [TelemetryPub,TelemetrySub,CommandsSub,CommandsPub] is to test out the Python Library "NATS". 
Its a PubSub async library that is used for communications between two nodes.

SETUP
In order to run the code, first download this docker image:
https://hub.docker.com/_/nats/ 
and then run:
docker compose up

Afterwards, run either the pub file first than its corresponding Sub file.

