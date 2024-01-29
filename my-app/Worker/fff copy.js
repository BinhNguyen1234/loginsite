onmessage = async (data) => {
  const chunkSize = 1024 * 1024; // size of each chunk (1MB)
  let start = 0;
  const file = data.data;
  console.log(file);
  await fetchByBatch(chunkSize, 3, 3000, data.data, 3);
  // while (start < file.size) {
  //   let a = new Promise((rs,rj)=>{
  //     setTimeout(()=>{rs(file.slice(start, start + chunkSize))},3000)
  //   })
  //   console.log(await a)
  //   start += chunkSize;
  // }
  // for (let i = 0; i < 5; i++){
  //   let a = new Promise((rs,rj)=>{
  //     setTimeout( async ()=>{
  //       let result = await fetch("https://jsonplaceholder.typicode.com/posts")
  //       rs(result)
  //     },3000)
  //   })

  //   console.log(await a)
  //   start += chunkSize;
  // }
};
async function fetchByBatch(chunkSize, batch, timeOut, file, retry = 1) {
  let start = 0;
  let reject = [];
  while ((start < file.size) && (retry > 0)) {
    let request = [];
    for (let i = 0; i < batch; i++) {
      // request.push(new FormData().append("file",file.slice(start, start + chunkSize)))
      request.push(fetch("https://jsonplaceholder.typicode.com/posts"));
      start += chunkSize;
    }
    let current = start;
    let FecthBacth = new Promise((resolve, reject) => {
      setTimeout(() => {
        Promise.all(request)
          .then((rs) => {
            rs.forEach((data) => {
              if (!data.ok) {
                throw new Error("Error with data from server");
              }
            })
            resolve();
          })
          .catch((e) => {
            console.log(e,"fffff")
            start -= current;
            retry -= 1;
          });
      }, timeOut);
    });
    await FecthBacth;
  }
}
