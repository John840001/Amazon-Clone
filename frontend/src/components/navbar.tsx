import React from "react";

const Navbar: React.FC = () => {
  return (
    <nav className="flex justify-between items-center p-4 bg-gray-800 text-white">
      <div className="text-2xl font-bold">
        <a href="/">Amazon Clone</a>
      </div>
      <ul className="flex space-x-4">
        <li>
          <a href="/products" className="hover:underline">
            Products
          </a>
        </li>
        <li>
          <a href="/cart" className="hover:underline">
            Cart
          </a>
        </li>
        <li>
          <a href="/account" className="hover:underline">
            Account
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default Navbar;
