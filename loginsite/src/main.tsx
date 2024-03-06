import React from 'react';
import ReactDOM from 'react-dom/client';
import router from './views/index.tsx';
import { Provider } from 'react-redux';
import store from './store/index.ts';
import './index.css';
import { RouterProvider } from 'react-router-dom';
ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <Provider store={store}>
            <RouterProvider router={router} />
        </Provider>
    </React.StrictMode>
);

