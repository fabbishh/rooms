import { Outlet } from 'react-router-dom';
import TourAgencySideBar from '../components/tourAgency/TourAgencySideBar';

interface LayoutProps {
  children: React.ReactNode
}

const SidebarLayout = (props: LayoutProps) => (
  <div className='flex'>
    {props.children}
    <div className="container mx-auto mt-8 bg-white min-h-screen">
      <Outlet />
    </div>
  </div>
);

export default SidebarLayout