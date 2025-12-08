import { createSlice } from '@reduxjs/toolkit';

type UserState ={
  userName: string | null;
  token: string | null;
  loggedIn: boolean;
};

const storedLoggedIn = sessionStorage.getItem('loggedIn');
const parsedLoggedIn = storedLoggedIn ? JSON.parse(storedLoggedIn) : { loggedIn: false };
const loggedIn = Boolean(parsedLoggedIn?.loggedIn);

const initialState: UserState = {
  userName: localStorage.getItem('userName'),
  token: localStorage.getItem('token'),
  loggedIn,
};

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    loginUser: (state, action) => {
      const { userName, token } = action.payload;
      state.loggedIn = true;
      state.userName = userName;
      state.token = token;

      sessionStorage.setItem('loggedIn', JSON.stringify({ loggedIn: true }));
    },
    logoutUser: (state) => {
      state.loggedIn = false;
      state.userName = null;
      state.token = null;

      sessionStorage.setItem('loggedIn', JSON.stringify({ loggedIn: false }));
    },
  },
});

export const { actions } = userSlice;
export default userSlice.reducer;
