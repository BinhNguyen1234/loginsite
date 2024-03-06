import { createSlice } from '@reduxjs/toolkit';
export const counterSlice = createSlice({
    name: 'counter',
    initialState: {
        value: 3
    },
    reducers: {
        increment: (state) => {
            const value = state.value + 1;
            return { ...state, value };
        }
    }
});
export const { increment } = counterSlice.actions;
export default counterSlice.reducer;
