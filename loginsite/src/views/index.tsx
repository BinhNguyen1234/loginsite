import { createBrowserRouter } from 'react-router-dom';
import SignUp from './SignUp/Signup.view.tsx';
import SignIn from './SignIn/Signin.view.tsx';
import MainLayout from './MainLayout.tsx';
// eslint-disable-next-line @typescript-eslint/no-unused-vars
const router = createBrowserRouter([
    {
        element: <MainLayout />,
        children: [
            {
                path: '/',
                element: <SignIn />
            },
            {
                index: true,
                path: '/signin',
                element: <SignIn />
            },
            {
                path: '/signup',
                element: <SignUp />
            }
        ]
    }
]);
export default router;
