import os
import asyncio
import time

import nats
from nats.errors import TimeoutError

servers = os.environ.get("NATS_URL", "nats://localhost:4222").split(",")

async def main():

    nc = await nats.connect(servers=servers)
    
    sub = await nc.subscribe("foo")

    while True:
        
        current_time = time.ctime()
        urmom = "{number: 9}" + "\nCurrent time: " + str(current_time)
        
        await nc.publish("foo", bytes(urmom,encoding='utf-8'))
        time.sleep(2)
        await sub.next_msg()
        print("Running")

    await nc.close()




if __name__ == '__main__':
    asyncio.run(main())