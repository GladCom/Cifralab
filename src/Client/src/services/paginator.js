import _ from 'lodash';

export const getDataForPage = (data, currentPage, pageSize) => {
    try {
        const chunks = _.chunk(data, pageSize);
        const dataChunks = chunks.map((items, index) => ({ items, pageNumber: index }));

        return dataChunks[currentPage]?.items;
      } catch (e) {
        console.error(e);
        
        return [];
      }
};