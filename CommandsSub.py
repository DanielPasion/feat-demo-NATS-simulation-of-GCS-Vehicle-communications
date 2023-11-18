import asyncio
import nats
import os 
from nats.errors import TimeoutError

servers = os.environ.get("NATS_URL", "nats://localhost:4222").split(",")

async def main():
    # Connect to NATS!
    nc = await nats.connect(servers=servers)

    # Receive messages on 'foo'
    sub = await nc.subscribe("foo")
    
    # Process a message
    while True: 
        try:
            msg = await sub.next_msg(timeout=.1)
            print("Received:", msg)
        except TimeoutError:
            pass

        


if __name__ == '__main__':
    asyncio.run(main())