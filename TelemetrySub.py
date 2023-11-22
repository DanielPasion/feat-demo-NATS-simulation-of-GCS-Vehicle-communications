import asyncio
import nats
import os 
from nats.errors import TimeoutError

#Runs on a docker server
servers = os.environ.get("NATS_URL", "nats://localhost:4222").split(",")

async def main():

    nc = await nats.connect(servers=servers)

    
    sub = await nc.subscribe("foo")

    try:
        msg = await sub.next_msg(timeout=.1)
    except TimeoutError:
        pass
    
    
    while True: 
        msg = await sub.next_msg(timeout=5)
        print("Received:", msg)
        


if __name__ == '__main__':
    asyncio.run(main())
