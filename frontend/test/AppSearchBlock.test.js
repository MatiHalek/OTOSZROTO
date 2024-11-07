import { mount } from '@vue/test-utils';
import ProfileSearch from '../components/UI/AppSearchBlock.vue';

describe('ProfileSearch.vue - Search Bar test', () => {
    it('should update searchValue when typing in the search input', async () => {
        const wrapper = mount(ProfileSearch);
        const searchInput = wrapper.find('input[placeholder="Wyszukaj..."]');
        
        await searchInput.setValue('Audi');

        expect(searchInput.element.value).toBe('Audi');
    });
});
