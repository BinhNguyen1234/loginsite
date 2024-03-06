import { configureStore } from '@reduxjs/toolkit';
import counterSliceReducer from '@store/counter/counter.slice.ts';
const store = configureStore({
    reducer: {
        counter: counterSliceReducer
    }
});

export type AppDispatch = typeof store.dispatch;
export type GlobalState = ReturnType<typeof store.getState>;
export default store;
