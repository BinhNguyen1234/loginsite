import Galaxy from '@components/Galaxy';
import { Outlet } from 'react-router-dom';

export default function MainLayout() {
    return (
        <>
            <Galaxy></Galaxy>
            <Outlet></Outlet>
        </>
    );
}
