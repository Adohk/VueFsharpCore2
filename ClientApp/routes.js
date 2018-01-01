import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import FetchDataDb from 'components/fetch-data-db'
import HomePage from 'components/home-page'

export const routes = [
    { path: '/', alias: "*", component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
    { path: '/fetch-data-db', component: FetchDataDb, display: 'Fetch data Db', style: 'glyphicon glyphicon-th-list' }
]