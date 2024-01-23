import { configureStore } from '@reduxjs/toolkit'
import {a }from './counter'
import Token from './counter'
export const makeStore = (token:any) => {
  const tok = Token(token)
  const c = a
  return configureStore({
    reducer: {
      token: tok.reducer,
      tok2: a.reducer
    },
    devTools: true
  })
}

// Infer the type of makeStore
export type AppStore = ReturnType<typeof makeStore>
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<AppStore['getState']>
export type AppDispatch = AppStore['dispatch']