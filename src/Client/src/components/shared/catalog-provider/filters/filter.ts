import { DtoKeys } from '../../../../storage/service/types';

interface Filter {
    key: string;
    backendKey: string | DtoKeys;
    label: string;
    placeholder?: string;
    useQuery: UseQueryHook;
    mapOptions?: (data: unknown) => SelectOption[];
}

interface UseQueryResult<T = unknown> {
    data: T;
    isLoading: boolean;
}

interface SelectOption {
    value: string | number;
    label: string;
}

interface Query {
    [key: string]: string | number | undefined;
}

interface FilterConfig {
    filters?: Filter[];
}

interface FilterSelectProps {
    filter: Filter;
    query: Query;
    setQuery: React.Dispatch<React.SetStateAction<Query>>;
}

interface FilterPanelProps {
    config?: FilterConfig;
    query: Query;
    setQuery: React.Dispatch<React.SetStateAction<Query>>;
}
  

type UseQueryHook = (params?: Record<string, unknown>) => UseQueryResult;

export type { FilterSelectProps, FilterPanelProps };