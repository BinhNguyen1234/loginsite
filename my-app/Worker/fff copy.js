onmessage = async (data) => {
  const chunkSize = 1024 * 1024; // size of each chunk (1MB)
  let start = 0;
  const file = data.data;
  await fetchByBatch(chunkSize, 3, 3000, data.data, 100);
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
async function fetchByBatch(chunkSize = 1024*1024, batch = 3, timeOut = 3000, file, retry = 1) {
  let start = 0;
  retry *= batch;
  let timeoutWhenFaild = timeOut * 10
  let timeOutWhenSuccess = timeOut
  while (start < file.size && retry > 0) {
    let request = [];
    for (let i = 0; i < batch; i++) {
      request.push(
        fetch("https://jsonplaceholder.typicode.com/posts").catch((e) => {
          console.log(e)
          return e;
        })
      );
      start += chunkSize;
    }
    let FecthBacth = new Promise((resolve, reject) => {
      setTimeout(() => {
        Promise.all(request).then((rs) => {
          rs.forEach((data) => {
            if (!data.ok) {
              start -= chunkSize;
              retry -=1;
              timeOut = timeoutWhenFaild
            } else {
              timeOut = timeOutWhenSuccess
            }
          });
          resolve();
        });
      }, timeOut);
    });
    await FecthBacth;
  }
}
