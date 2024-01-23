import { createSlice } from "@reduxjs/toolkit"
export default function Token (token : string){
    console.log(token)
    return createSlice({
        name: 'token',
        initialState: {
            accessToken: token
        },
        reducers: {

        },
      })
}

let a = createSlice({
    name: 'token',
    initialState: {
        accessToken: {
            accessToken:"asdasdasdasd"
        }
    },
    reducers: {},
  })
  export { a}