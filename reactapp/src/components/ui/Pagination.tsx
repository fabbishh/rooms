// Pagination.tsx
import React from 'react';
import ReactPaginate from 'react-paginate';

interface PaginationProps {
  pageSize: number;
  totalPages: number;
  onPageChange: (event: any) => void;
  pageNumber: number;
}

const Pagination: React.FC<PaginationProps> = ({ pageSize, totalPages, pageNumber, onPageChange }) => {

  return (
    <>
      <ReactPaginate
				breakLabel="..."
				nextLabel=">"
				forcePage = {pageNumber}
				onPageChange={onPageChange}
				pageRangeDisplayed={pageSize}
				pageCount={totalPages}
				previousLabel="<"
				pageClassName="inline-block mx-1 px-3 py-2 hover:bg-"
				pageLinkClassName="text-cyan-700"
				previousClassName="inline-block mx-1 px-3 py-2 "
				previousLinkClassName="text-cyan-700"
				nextClassName="inline-block mx-1 px-3 py-2 "
				nextLinkClassName="text-cyan-700"
				breakClassName="inline-block mx-1 px-3 py-2 "
				breakLinkClassName="text-cyan-700"
				containerClassName="flex items-center justify-center pagination"
				activeClassName="bg-cyan-700 bg-opacity-10 rounded-full"
				renderOnZeroPageCount={null}
			/>
    </>
  );
};

export default Pagination;
