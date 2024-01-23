import { createReducer, createSlice } from "@reduxjs/toolkit"
export default function Token (token : string){
    console.log(token)
    return createSlice({
        name: 'token',
        initialState: {
            accessToken: token
        },
        reducers: {
            fff: (crState, action)=>{
                console.log(action)
                return {accessToken: action.payload}
            }
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
    reducers: {
        test: (cr, action) =>{
            return {...cr}
        }
    },
  })
  let test = a.actions.test
  export { a,test}