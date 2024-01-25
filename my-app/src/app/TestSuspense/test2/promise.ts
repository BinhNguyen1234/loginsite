let prms = new Promise((rs,rj)=>{
    setTimeout(()=>{
        rs("ffasd Test")
    },6000)
})
export {prms}