
onmessage = (data)=>{
    const chunkSize = 1024 * 1024; // size of each chunk (1MB)
    let start = 0;
    const file = data.data
    console.log(file)
    while (start < file.size) {
      console.log(file.slice(start, start + chunkSize))
      start += chunkSize;
    }
}