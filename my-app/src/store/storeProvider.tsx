'use client'
import { useRef } from 'react'
import { Provider } from 'react-redux'
import { makeStore, AppStore } from './store'

export default function StoreProvider({
  children, token
}: {
  children: React.ReactNode, token: string
}) {
  const storeRef = useRef<AppStore>()
  if (!storeRef.current) {
    // Create the store instance the first time this renders
    storeRef.current = makeStore(token)
  }

  return <Provider store={storeRef.current}>{children}</Provider>
}